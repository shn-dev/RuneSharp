


RuneSharp
=
RuneSharp is a C# wrapper for the Runescape API. With RuneSharp, you can retrieve data from Runescape like item details and grand exchange histories. The intention here is to allow you to use C# to quickly and efficiently use the Runescape API so you can get started on an ASP.NET application or the likes.

Types of Requests to the API
---
**Item Details**

Say we are interested in getting the details of a random item in Runescape. We can retrieve all sorts of information for the item, such as, but not limited to:

 - Small and large icons for the item
 - Whether the item is gaining value or not
 - The percent increase/decrease of the item
 - The item description
 - The item name
 - The current price of the item

Here is an example of making the request to the API using C# for a Drygore Longsword:

    //The Drygore Longsword's item ID = 26587.
    //the getDetail(int ID) method retrieves the item
    var dLong = RuneMethods.getDetail(26587);
    //get the item's current price
    var itemPrice = dLong.item.current.price;
    //get the item description
    var itemDescription = dLong.item.description;
    //get the item's large icon
    //var itemIcoLarge = dLong.item.icon_large;

There are many other item properties that you can use. Try it out!

**Catalogue**

The catalogue allows us to view how many items exist for a certain category of item, such as "ammo" or "herblore materials." Each item per category polled will be grouped via the starting letter of the item. 

	var cata = RuneMethods.getCatalogue(Models.ItemCategory.Ammo);
	
	foreach(Models.CatalogueResponse.Alpha letter in cata.alpha){
	
	Console.WriteLine("There are " + letter.items 
                + " items starting with letter " + letter.letter 
                + " in " + Models.ItemCategory.Ammo.ToString());
	}

Resulting output:

>There are 6 items starting with letter a in Ammo
There are 10 items starting with letter b in Ammo
There are 6 items starting with letter c in Ammo
There are 4 items starting with letter d in Ammo
There are 0 items starting with letter e in Ammo
There are 0 items starting with letter f in Ammo
There are 1 items starting with letter g in Ammo
There are 2 items starting with letter h in Ammo
There are 5 items starting with letter i in Ammo
There are 0 items starting with letter j in Ammo
There are 1 items starting with letter k in Ammo
There are 1 items starting with letter l in Ammo
There are 10 items starting with letter m in Ammo
There are 0 items starting with letter n in Ammo
There are 25 items starting with letter o in Ammo
There are 0 items starting with letter p in Ammo
There are 0 items starting with letter q in Ammo
There are 6 items starting with letter r in Ammo
There are 5 items starting with letter s in Ammo
There are 2 items starting with letter t in Ammo
There are 0 items starting with letter u in Ammo
There are 1 items starting with letter v in Ammo
There are 1 items starting with letter w in Ammo
There are 0 items starting with letter x in Ammo
There are 0 items starting with letter y in Ammo
There are 0 items starting with letter z in Ammo

If we want to view all items for a certain letter and category, we can do so be reading the paragraph immediately below.
    
**Exploring Items**

If we actually want to retrieve the items for a specific category, we must do so by also specifying the starting letter of the items. For instance, "retrieve all ammo that starts with the letter 'a'." That code would look like this:

    var items = RuneMethods.getItems(itemCategory.Ammo, 'a');
    string itemNames= "";
    foreach(Models.ItemsResponse.Item item in items.items){
	    itemNames += item.name + " ";
    }
   The resulting output will be:
   >Adamant brutal. Adamant dart. Adamant javelin. Adamant knife. Adamant throwing axe. Azure skillchompa. 
 
 It's important to note that we can only display 12 entries per page. If we return more than 12 entries, we have to revise the initial *getItems()* method to include the desired pagenumber. I.e. results 13-24 would require using *pageNumber = 2*. You specify the pageNumber in the overloaded *getItems()* method (that is, add a third parameter to the method).
 
**Graphing**

We can obtain daily price histories for the past 180 days (6 months) for any item in the Runescape database. This is especially useful for creating your own graphs with histories that track data pertaining to an item or comparing items. The following returns the date and "daily" price (as opposed to "average" price) of the Drygore Longsword for the past 6 months:

    var dLongGraph = RuneMethods.getGraph(26587);
    var dLongGraphData = dLongGraph.daily.GraphPoints;
	foreach(Models.GraphResponse.GraphPoint point in dLongGraphData)  
	{
	    Console.WriteLine(point.date + " " + point.price);
	}

The output of the code will be:
>6/22/2016 12:00:00 AM 21435548
>6/23/2016 12:00:00 AM 21343777
>...
>12/17/2016 12:00:00 AM 20595343
>12/18/2016 12:00:00 AM 21362684

Where the value on the left is the date, and the value on the right is the value of the Drygore Longsword for that date in gp.