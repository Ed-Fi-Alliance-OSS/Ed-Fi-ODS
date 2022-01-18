using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EdFi.Security.DataAccess.Models
{
    public class ResourceClaimActionAuthorizationStrategies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceClaimActionAuthorizationStrategyId { get; set; }

        public int ResourceClaimActionId { get; set; }

        [Required]
        [ForeignKey("ResourceClaimActionId")]
        public ResourceClaimAction ResourceClaimAction { get; set; }

        public int AuthorizationStrategyId { get; set; }

        [Required]
        [ForeignKey("AuthorizationStrategyId")]
        public AuthorizationStrategy AuthorizationStrategy { get; set; }
    }
}
