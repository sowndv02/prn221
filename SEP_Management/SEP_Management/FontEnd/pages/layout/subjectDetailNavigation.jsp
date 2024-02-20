<%-- 
    Document   : subjectDetailNavigation
    Created on : Oct 28, 2023, 6:47:43 PM
    Author     : hungd
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>

<ul class="nav nav-pills nav-justified flex-column flex-sm-row rounded shadow overflow-hidden bg-light"
    id="pills-tab" role="tablist">
    <li class="nav-item">
    <c:forEach items="${listDetails}" var="sd">
        <a class="nav-link rounded-0" id="nav-subject-general"
           href="manageSubjectController?service=displayDetails&subjectID=${sd.subjectId}" role="tab">
            <div class="text-center pt-1 pb-1">
                <h4 class="title fw-normal mb-0">General</h4>
            </div>
        </a><!--end nav link-->
    </c:forEach>
</li><!--end nav item-->

<li class="nav-item">
<c:forEach items="${listDetails}" var="sd">
    <a class="nav-link rounded-0" id="nav-subject-assignment"
       href="manageSubjectController?service=displayAssignment&subjectID=${sd.subjectId}" role="tab" >
        <div class="text-center pt-1 pb-1">
            <h4 class="title fw-normal mb-0">Assignments</h4>
        </div>
    </a><!--end nav link-->
</c:forEach>
</li><!--end nav item-->
<li class="nav-item">
<c:forEach items="${listDetails}" var="sd">
    <a class="nav-link rounded-0" id="nav-subject-setting"
       href="IssueSettingController?service=displayIssueSetting&subjectID=${sd.subjectId}&mode=subject" role="tab">
        <div class="text-center pt-1 pb-1">
            <h4 class="title fw-normal mb-0">Settings</h4>
        </div>
    </a><!--end nav link-->
</c:forEach>
</li><!--end nav item-->
</ul><!--end nav pills-->

