
#r "System.Xml.Linq.dll"
open System.Xml.Linq
open System.Linq

let FILE_WORDPRESS_XML = "input\\sample.xml"

let doc = XDocument.Load FILE_WORDPRESS_XML 

let xName = XName.Get

let item = query {
        for de in doc.Descendants(xName "item") do
            select de.Name
    }

item.ToArray()

let de = doc.Elements()

de.First().



de.Descendants(xName "item") 
|> Seq.map(fun (x: XElement)-> x.Elements(xName "title").First().Name )

let (a:XElement) = null
a.

let ShowNames (els: seq<XElement>) = els |> Seq.map(fun x-> x.Name.ToString() )

de.Elements(xName "rss")  |>  ShowNames
;;

let GetChild name (elx: XElement) = elx.Elements(xName name)

let (many: XElement seq) = de.First().Elements().First().Elements() 
many.Count()

de.


