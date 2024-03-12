using GitLabApiClient;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Utils
{
    public class SyncGitLab
    {
        public async Task SyncMilestonesWithProject(Project project)
        {
            GitLabClient gitLabClient = new GitLabClient("https://gitlab.com", project.AccessToken);
            List<GitLabApiClient.Models.Milestones.Responses.Milestone> gitlabMilestones = await GetListMilestoneGitLabAsync(gitLabClient, project);
            using (var context = new SEP_ManagementContext())
            {
                List<Milestone> dbMmilestones = await context.Milestones.Where(x => x.ProjectId == project.ProjectId).ToListAsync();

            }
        }


        public async Task<List<GitLabApiClient.Models.Milestones.Responses.Milestone>> GetListMilestoneGitLabAsync(GitLabClient gitLabClient, Project project)
        {
            List<GitLabApiClient.Models.Milestones.Responses.Milestone> list = (List<GitLabApiClient.Models.Milestones.Responses.Milestone>)await gitLabClient.Projects.GetMilestonesAsync(GetProjectPath(project.Url));
            return list;
        }

        private string GetProjectPath(string url)
        {
            return url.Split("https://gitlab.com")[1];
        }

    }
}
