using System.Collections.Generic;

namespace AMZEnterpriseWebsite.Models
{
    public class Pagination
    {
        public Pager Pager { get; set; }

        /// <summary>
        /// Query string parameters dictionary
        /// </summary>
        public Dictionary<string, string> Params { get; set; }
    }
}
