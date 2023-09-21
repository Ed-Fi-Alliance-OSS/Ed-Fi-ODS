using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EdFi.Security.DataAccess.Models
{
    [Index(nameof(ClaimSetResourceClaimActionId),nameof(ClaimSetResourceClaimActionAuthorizationStrategyOverrideId), IsUnique = true)]
    public class ClaimSetResourceClaimActionAuthorizationStrategyOverrides
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClaimSetResourceClaimActionAuthorizationStrategyOverrideId { get; set; }

        public int ClaimSetResourceClaimActionId { get; set; }

        [Required]
        [ForeignKey("ClaimSetResourceClaimActionId")]
        public ClaimSetResourceClaimAction ClaimSetResourceClaimAction { get; set; }

        public int AuthorizationStrategyId { get; set; }

        [Required]
        [ForeignKey("AuthorizationStrategyId")]
        public AuthorizationStrategy AuthorizationStrategy { get; set; }
    }
}