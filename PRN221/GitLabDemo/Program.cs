

using GitLabApiClient;
using GitLabApiClient.Models.Milestones.Responses;

internal class Program
{
    static async Task Main(string[] args)
    {
        // Replace with your GitLab API URL and access token
        var gitLabClient = new GitLabClient("https://gitlab.com", "glpat-nzBa34x92TZWxKx2hxky");

        try
        {
            var milestones = await GetMilestones(gitLabClient, "sondvhe164023/swp391");

            foreach (var milestone in milestones)
            {
                Console.WriteLine($"Milestone ID: {milestone.Id}, Title: {milestone.Title}, Description: {milestone.Description}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static async Task<IEnumerable<Milestone>> GetMilestones(GitLabClient gitLabClient, string projectPath)
    {
        // Retrieve milestones for the project
        var milestones = await gitLabClient.Projects.GetMilestonesAsync(projectPath);

        return milestones;
    }
}