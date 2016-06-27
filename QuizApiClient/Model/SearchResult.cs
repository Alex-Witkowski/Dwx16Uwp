using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApiClient.Model
{
    public class SearchResult
    {
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public int page { get; set; }
        public int image_set_count { get; set; }
        public Set[] sets { get; set; }
    }

    public class Set
    {
        public int id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string created_by { get; set; }
        public int term_count { get; set; }
        public int created_date { get; set; }
        public int modified_date { get; set; }
        public int published_date { get; set; }
        public bool has_images { get; set; }
        public object[] subjects { get; set; }
        public string visibility { get; set; }
        public string editable { get; set; }
        public bool has_access { get; set; }
        public bool can_edit { get; set; }
        public string description { get; set; }
        public string lang_terms { get; set; }
        public string lang_definitions { get; set; }
        public int password_use { get; set; }
        public int password_edit { get; set; }
        public int access_type { get; set; }
        public int creator_id { get; set; }
        public Creator creator { get; set; }
        public int[] class_ids { get; set; }
        public Term[] terms { get; set; }
    }

    public class Creator
    {
        public string username { get; set; }
        public string account_type { get; set; }
        public string profile_image { get; set; }
        public int id { get; set; }
    }

    public class Term
    {
        public long id { get; set; }
        public string term { get; set; }
        public string definition { get; set; }
        public Image image { get; set; }
        public int rank { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }


}
