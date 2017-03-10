
#r "System.Xml.Linq.dll"
open System.Xml.Linq
open System.Linq

// XML Namespaces
let xmlNS = XName.Get
let xmlWP name = XName.Get (name, "http://wordpress.org/export/1.2/")

// XML Function Utils
let GetDescendent name (doc: XDocument) = doc.Descendants(xmlNS name)
let GetChild (item: XElement) name = item.Element(xmlNS name).Value

// Verify if the item is a post indeed
let IsPost (item: XElement) = (item.Element(xmlWP "post_type").Value = "post")

// Just do it!

"input\\sqlblogninja.wordpress.xml" 
    |> XDocument.Load
    |> GetDescendent "item"
    |> Seq.filter( IsPost )
    |> Seq.map( fun item -> 
        (GetChild item "title" , GetChild item "link" ) )
