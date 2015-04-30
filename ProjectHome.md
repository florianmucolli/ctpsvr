to provide citiport ipad data fetching proxy

### URL: ###
{citiport proxy url} /svr.ashx?

### Parameter: ###

notice: request string has to be UTF8 encoded

&method={"wiki", "flickr", "ftile", "geocode", "flickrfirst", "places"}
> (required)task
&key={...}
> (required)keyword

&encoding={"utf8"}
> {optional)the encoding for response content

### Request Example ###
```
//response will be a jpeg image
/svr.ashx?method=ftile&key=taipei

//request for near places
/svr.ashx?method=places&key=34.12312,120.450

//request for chicago wiki data encoded in UTF8
/svr.ashx?method=wiki&key=chicago&encoding=utf8
```

### Response Example ###
```
///svr.ashx?method=wiki&key=taipei

{

     status: "OK",
     msg: "",
     data: [ …
  
            {
                + id: "4467285752"
                + title: "Taipei+for+Earth+Hour+2010+%e5%8f%b0%e5%8c%97%e7%82%ba%e5%9c%b0%e7%90%83%e9%97%9c%e7%87%881%e5%b0%8f%e6%99%82"
                + url: http://farm3.static.flickr.com/2792/4467285752_c57a8b7731_m.jpg
            }
        
      ],
     foo: "bar"

}
```


---


contact: jeff@citiport.net