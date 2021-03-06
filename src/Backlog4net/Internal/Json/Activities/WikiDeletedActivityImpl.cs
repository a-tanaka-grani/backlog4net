﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Backlog4net.Internal.Json.Activities
{
    public class WikiDeletedActivityImpl : ActivityJsonImpl<WikiDeletedContentImpl>, WikiDeletedActivity
    {
        public override ActivityType Type => ActivityType.WikiDeleted;

        WikiDeletedContent WikiDeletedActivity.Content => this.Content;
    }

    public class WikiDeletedContentImpl : WikiDeletedContent
    {
        [JsonProperty]
        public long Id { get; private set; }

        [JsonProperty()]
        public string Name { get; private set; }

        [JsonProperty]
        public string Content { get; private set; }

        [JsonProperty]
        public string Diff { get; private set; }

        [JsonProperty]
        public int? Version { get; private set; }

        [JsonProperty(ItemConverterType = typeof(AttachmentJsonImpl.JsonConverter))]
        public IList<Attachment> Attachments { get; private set; }

        [JsonProperty("shared_files", ItemConverterType = typeof(SharedFileJsonImpl.JsonConverter))]
        public IList<SharedFile> SharedFiles { get; private set; }
    }
}
