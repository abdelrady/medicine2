using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using System.Globalization;
using System.Text.RegularExpressions;
using Raven.Database.Indexing;


public class Index_Auto_2fItems_2fByCategoryAndName : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fItems_2fByCategoryAndName()
	{
		this.ViewText = @"from doc in docs.Items
select new { Category = doc.Category, Name = doc.Name }";
		this.ForEntityNames.Add("Items");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "Items", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				Category = doc.Category,
				Name = doc.Name,
				__document_id = doc.__document_id
			});
		this.AddField("Category");
		this.AddField("Name");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("Category");
		this.AddQueryParameterForMap("Name");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("Category");
		this.AddQueryParameterForReduce("Name");
		this.AddQueryParameterForReduce("__document_id");
	}
}
