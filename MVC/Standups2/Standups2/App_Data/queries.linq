Products.OrderBy(p => p.ProductID).Take(10)
Products.Count()
Products.Select(p => p.ListPrice).Average()
Products.Select(p => p.ListPrice).Distinct()
Products.Select(p => new {Price=p.ListPrice, Name=p.Name, Color=p.Color})
Products.Find(316).ProductProductPhotoes
	.Select(ppp => new {Filename=ppp.ProductPhoto.LargePhotoFileName, 
	ID = ppp.ProductPhoto.ProductPhotoID, Data=ppp.ProductPhoto.LargePhoto})