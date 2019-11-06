Products.Where(p => p.Name.Contains("Logo")).Average(p => p.ListPrice)
Products.Average(p => p.ListPrice)

ProductCategories.Select(pc => new {ID = pc.ProductCategoryID, name = pc.Name}).ToList()

ProductCategories.Find(1).ProductSubcategories.Where(psc => psc.Name == "Touring Bikes").First().Products
.Select(p => new {name=p.Name})
