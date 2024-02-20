<%-- 
    Document   : projectNavigation
    Created on : Nov 5, 2023, 4:35:06 PM
    Author     : TRAN DUNG
--%>

<%@page import="java.sql.ResultSet"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <div class="p-4">
            <div class="row">
                <div class="col-lg-12">
                    <ul class="nav nav-pills nav-justified flex-column flex-sm-row rounded" id="pills-tab" role="tablist">
                        <%
                            int status = (int) request.getAttribute("status");
                            String currentMentorName = (String) request.getAttribute("currentMentorName");
                            String currentCo_MentorName = (String) request.getAttribute("currentCo_MentorName");
                            ResultSet rsProject = (ResultSet) request.getAttribute("rsProject");
                            ResultSet rsClassCode = (ResultSet) request.getAttribute("rsClassCode");
                            ResultSet rsAllMentorName = (ResultSet) request.getAttribute("rsAllMentorName");
                            ResultSet rsAllCo_MentorName = (ResultSet) request.getAttribute("rsAllCo_MentorName");
                                while (rsProject.next()) {
                        %>
                        <%if(role!=18){%>
                        <li class="nav-item">
                            <a class="nav-link rounded active" id="pills-cloud-tab" data-bs-toggle="pill" href="#pills-cloud" role="tab" aria-controls="pills-cloud" aria-selected="true">
                                <div class="text-center pt-1 pb-1">
                                    <h4 class="title font-weight-normal mb-0">General</h4>
                                </div>
                            </a><!--end nav link-->
                        </li><!--end nav item-->

                        <li class="nav-item">
                            <a class="nav-link rounded" href="ManageProjectController?service=listMilestones&project_id=<%=rsProject.getString(1)%>" role="tab" aria-controls="pills-smart" aria-selected="false">
                                <div class="text-center pt-1 pb-1">
                                    <h4 class="title font-weight-normal mb-0">Milestone</h4>
                                </div>
                            </a><!--end nav link-->
                        </li><!--end nav item-->

                        <li class="nav-item">
                            <a class="nav-link rounded"  href="IssueSettingController?service=displayProjectSetting&projectID=<%=rsProject.getString(1)%>&mode=project" role="tab" aria-controls="pills-apps" aria-selected="false">
                                <div class="text-center pt-1 pb-1">
                                    <h4 class="title font-weight-normal mb-0">Settings</h4>
                                </div>
                            </a><!--end nav link-->
                        </li><!--end nav item-->
                        <li class="nav-item">
                            <a class="nav-link rounded"  href="IssueSettingController?service=ListProjectIssue&projectID=<%=rsProject.getString(1)%>" role="tab" aria-controls="pills-apps" aria-selected="false">
                                <div class="text-center pt-1 pb-1">
                                    <h4 class="title font-weight-normal mb-0">Issue</h4>
                                </div>
                            </a><!--end nav link-->
                        </li><!--end nav item-->
                        <%}%>
                    </ul><!--end nav pills-->
                </div><!--end col-->
            </div><!--end row-->
    </body>
</html>
