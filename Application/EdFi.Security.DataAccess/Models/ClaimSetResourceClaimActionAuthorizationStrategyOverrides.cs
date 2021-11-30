using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EdFi.Security.DataAccess.Models
{
    public class ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClaimSetResourceClaimActionAuthorizationStrategyOverrideId { get; set; }

        [Required]
        [Index(IsUnique = true, Order = 1)]
        public ClaimSetResourceClaimActionAuthorizations ClaimSetResourceClaimActionAuthorization { get; set; }

        [Required]
        [Index(IsUnique = true, Order = 2)]
        public AuthorizationStrategy AuthorizationStrategy { get; set; }
    }
}