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

        public int ClaimSetResourceClaimActionId { get; set; }

        [Required]
        [Index(IsUnique = true, Order = 1)]
        [ForeignKey("ClaimSetResourceClaimActionId")]
        public ClaimSetResourceClaimAction ClaimSetResourceClaimAction { get; set; }

        public int AuthorizationStrategyId { get; set; }

        [Required]
        [Index(IsUnique = true, Order = 2)]
        [ForeignKey("AuthorizationStrategyId")]
        public AuthorizationStrategy AuthorizationStrategy { get; set; }
    }
}