﻿namespace CatalogMicroservice.Models
{
    public class ProductProperty
    {
        public long Id { get; set; }
        public long ProductId {  get; set; }
        public long PropertyId {  get; set; }
        public string Value {  get; set; }
        public Product? Product { get; set; }
        public Property? Property { get; set; }
    }
}
