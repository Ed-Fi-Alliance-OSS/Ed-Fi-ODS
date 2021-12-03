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

        public int ResourceClaimActionAuthorizationId { get; set; }

        [Required]
        [ForeignKey("ResourceClaimActionAuthorizationId")]
        public ResourceClaimActionAuthorization ResourceClaimActionAuthorization { get; set; }

        [Required]
        public AuthorizationStrategy AuthorizationStrategy { get; set; }
    }
}
