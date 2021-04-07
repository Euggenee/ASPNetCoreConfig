using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
  public class ComputerModelTag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string TageName { get; set; }
        public string TagMeta { get; set; }
        public string TagExpiration { get; set; }
        public string ComputerModelId { get; set; }
        public ComputerModel ComputerModel { get; set; }
    }
}
