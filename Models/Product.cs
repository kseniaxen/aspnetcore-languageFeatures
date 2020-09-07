using System;
using System.Collections.Generic;

namespace LanguageFeatures.Models {

    public class Product {

        public string Name { get; set; }
        public decimal? Price { get; set; }
        public Product Related { get; set; }
        public string Category { get; set; } = "Watersports";
        public bool InStock { get; } = true;
        
        public static List<Product> GetProducts() {
            Product kayak = new Product {
                Name = "Kayak", Price = 275M
            };
            Product lifejacket = new Product {
                Name = "Lifejacket", Price = 48.95M, Category = "Water Craft"
            };
            kayak.Related = lifejacket;
            return new List<Product> { kayak, lifejacket, null };
        }
    }
}