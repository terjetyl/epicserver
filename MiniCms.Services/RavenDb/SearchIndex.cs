using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniCms.Model.Entities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace MiniCms.Services.RavenDb
{
    public class SearchIndex : AbstractMultiMapIndexCreationTask<SearchIndex.Result>
    {
        public class Result
        {
            public object[] Content { get; set; }
        }

        public override string IndexName
        {
            get
            {
                return "SearchableItems/ByContent";
            }
        }

        public SearchIndex()
        {
            AddMap<BlogPost>(items => from x in items
                                      select new Result { Content = new object[] { x.Author, x.Body, x.Title, x.Tags } });

            //AddMap<Event>(items => from x in items
            //                       select new Result { Content = new object[] { x.Details, x.Title } });

            //AddMap<Page>(items => from x in items
            //                      select new Result { Content = new object[] { x.Body, x.Title } });

            Index(x => x.Content, FieldIndexing.Analyzed);
        }
    }
}
