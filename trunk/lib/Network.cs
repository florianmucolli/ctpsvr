using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Citiport.Network
{
    public interface IUrlFetcher
    {
        object fetch(String url);
    }

    public class SimpleUrlFetcher : IUrlFetcher
    {
        public object fetch(String url)
        {
            System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            _HttpWebRequest.AllowWriteStreamBuffering = true;
            System.IO.Stream _WebStream = null;
            System.Net.WebResponse _WebResponse = null;
            try
            {
                _WebResponse = _HttpWebRequest.GetResponse();
            }
            catch (System.Net.WebException webExcep)
            {
                //handle exception
                throw webExcep;
            }
            finally
            {
                if (_WebResponse != null)
                {
                    _WebStream = _WebResponse.GetResponseStream();
                }
            }
            return _WebStream;
        }
    }

    public class FlickrPhotoFetcher
    {
        public FlickrPhotoFetcher()
        {
            Fetcher = new SimpleUrlFetcher();
        }

        public IUrlFetcher Fetcher{set;get;}

        public List<Image> fetch(List<String> urls)
        {
            //List<Image> images = new List<Image>();
            //for (int i = 0; i < urls.Count; i++)
            //{
            //    String url = urls[i];
            //    Stream imageStream = (Stream)Fetcher.fetch(url);
            //    if (imageStream != null)
            //    {
            //        using (System.Drawing.Image _Image = System.Drawing.Image.FromStream(imageStream))
            //        {
            //            Image __image = new Bitmap(_Image);
            //            images.Add(__image);
            //        }
            //    }
            //}
            //return images;

            ConcurrentStack<Image> stack = new ConcurrentStack<Image>();
            Parallel.For(0, urls.Count, (i, loopState) =>
                {
                    String url = urls[i];
                    Stream imageStream = (Stream)Fetcher.fetch(url);
                    if (imageStream != null)
                    {
                        using (System.Drawing.Image _Image = System.Drawing.Image.FromStream(imageStream))
                        {
                            Image __image = new Bitmap(_Image);
                            stack.Push(__image);
                        }
                    }
                });
            return stack.ToList<Image>();
        }
    }
}
