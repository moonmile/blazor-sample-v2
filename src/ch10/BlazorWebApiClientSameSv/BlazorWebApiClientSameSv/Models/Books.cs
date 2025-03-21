using System;
using System.Collections.Generic;

namespace BlazorWebApiClientSameSv.Models
{
    public partial class Books
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Price { get; set; }
        public string Publisher { get; set; } = null!;
    }
}
