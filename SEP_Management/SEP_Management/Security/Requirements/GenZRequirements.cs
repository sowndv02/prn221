using Microsoft.AspNetCore.Authorization;

namespace SEP_Management.Security.Requirements
{
    public class GenZRequirements : IAuthorizationRequirement
    {
        public GenZRequirements(int fromYear = 1997, int toYear = 2012)
        {
            FromYear = fromYear;
            ToYear = toYear;
        }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
    }
}
