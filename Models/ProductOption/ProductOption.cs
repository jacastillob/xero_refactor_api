using System;
using Newtonsoft.Json;

namespace RefactorThis
{
    public class ProductOption
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore] public bool IsNew { get; set; }

        public ProductOption()
        {
            Id = Guid.NewGuid();
            IsNew = true;
        }

    }
}
