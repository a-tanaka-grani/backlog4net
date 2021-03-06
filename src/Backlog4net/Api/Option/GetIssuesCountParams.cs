﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backlog4net.Api.Option
{
    public class GetIssuesCountParams : GetParams
    {
        public GetIssuesCountParams(params long[] projectIds)
        {
            AddNewArrayParams("projectId[]", projectIds);
        }

        public IList<long> IssueTypeIds { set => AddNewArrayParams("issueTypeId[]", value); }

        public IList<long> CategoryIds { set => AddNewArrayParams("categoryId[]", value); }

        public IList<long> VersionIds { set => AddNewArrayParams("versionId[]", value); }

        public IList<long> MilestoneIds { set => AddNewArrayParams("milestoneId[]", value); }

        public IList<IssueStatusType> Statuses { set => AddNewArrayParams("statusId[]", value, x => x.ToString("D")); }

        public IList<IssuePriorityType> Priorities { set => AddNewArrayParams("priorityId[]", value, x => x.ToString("D")); }

        public IList<long> AssigneeIds { set => AddNewArrayParams("assigneeId[]", value); }

        public IList<long> CreatedUserIds { set => AddNewArrayParams("createdUserId[]", value); }

        public IList<IssueResolutionType> Resolutions { set => AddNewArrayParams("resolutionId[]", value, x => x.ToString("D")); }

        public GetIssuesParentChildType ParentChildType { set => AddNewParam("parentChild", value.ToString("D")); }

        public bool Attachment { set => AddNewParamValue(value); }

        public bool SharedFile { set => AddNewParamValue(value); }

        public DateTime CreatedSince { set => AddNewParamValue(ToDateString(value)); }

        public DateTime CreatedUntil { set => AddNewParamValue(ToDateString(value)); }

        public DateTime UpdatedSince { set => AddNewParamValue(ToDateString(value)); }

        public DateTime UpdatedUntil { set => AddNewParamValue(ToDateString(value)); }

        public DateTime StartDateSince { set => AddNewParamValue(ToDateString(value)); }

        public DateTime StartDateUntil { set => AddNewParamValue(ToDateString(value)); }

        public DateTime DueDateSince { set => AddNewParamValue(ToDateString(value)); }

        public DateTime DueDateUntil { set => AddNewParamValue(ToDateString(value)); }

        public IList<long> Ids { set => AddNewArrayParams("id[]", value); }

        public IList<long> ParentIssueIds { set => AddNewArrayParams("parentIssueId[]", value); }

        public string Keyword { set => AddNewParamValue(value); }

        public IList<GetIssuesCustomField> CustomFields
        {
            set
            {
                if (value != null)
                {
                    foreach (var param in value.SelectMany(x => x.Parameters)) { this.Parameters.Add(param); }
                }
            }
        }
    }

    public enum GetIssuesParentChildType
    {
        All = 0,
        NotChild = 1,
        Child = 2,
        NotChildNotParent = 3,
        Parent = 4
    }
}
