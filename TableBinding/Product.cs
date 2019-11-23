using System;

namespace TableBinding
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
