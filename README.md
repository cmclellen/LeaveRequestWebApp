Leave Request Web Application - The leave request application everyone is talking about...
=============================

Overview
========
This application manages leave requests submitted by non-managers. Managers are notified and are then able to accept/reject leave requests.
The clone URL is
<code>https://github.com/cmclellen/LeaveRequestWebApp.git</code>

The problem
===========

For the position you're interviewing for, we would prefer if your solution was in ASP.NET (C#, VB.NET or F#), but if you would like to use another language, please do so, but you should explain why you think this would be a better solution.
You can use any libraries and tools you wish, just note in your solution if it's not included. Please note that we will be revisiting your solution during your technical interview.
You can also include a brief explanation of your design and any assumptions you made along with your solution.
Problem:
Our customer has requested a proof-of-concept to allow employees to apply for leave through a reactive web application.
They have identified desktop and tablets as the target platforms.
The app will let employees request leave with a start and end date; a reason (Annual, Personal, Compassionate or Parental); and comments, and submit it to their manager for approval.
It will also allow the employee to see previous requests they have made.
Build the proof-of-concept for requesting leave, and viewing previous leave requests.

Reasons for choosing the technologies used
==========================================
<ul>
    <li>This solution was developed using <strong>MS Visual Studio Ultimate 2013</strong></li>
    <li>The user facing UI is served by a web application developed using ASP.NET MVC, and that was just to try keep things simple (ease of proof of concept), but it could have been a simple ExpressJs framework as the core of the workings lie in the javascript (client side).</li>
    <li>The web API was developed using ASP.NET WebAPI because of it's ease of setup, deployment, etc.</li>
    <li>Used a SQL Server CE database because it is a standalone minimilistic database that doesn't require a SQL Server instance to be installed. Also, due to my obsession with coding by contract, the code is decoupled enough to easily write concrete implementation of the various repositories for other databases (e.g. SQL Server, Oracle, MySql, Postgres, etc.)</li>
    <li>All configuration has been split out, making it easy enough for tools like MsDeploy to easily transform the configuration files for deployment to various environments (e.g. local, dev, staging, production, etc.).</li>
</ul>

Assumptions/Restrictions
========================
<ul>
  <li>In terms of security, there is none, as I just wanted to keep it simple for this proof of concept. The dropdown at top right hand corner is the means by which the application knows what user is currently using the system.</li>
  <li>The solution hasn't been localized (just English, and dates are stored in local time (rather than UTC))</li>
  <li>The solution could have been developed as a single project, using simple IMDB, etc. but I just wanted to show clean separation of concerns, easily testable code, as close to proper DB design as I was able to achieve (due to restrictions with Sql Server CE), etc.</li>
  <li>No transactioning has been added, but this (with isolation level ReadCommitted) would be added at WebAPI level and interceptor on each of the WebAPI actions to auto commit if no errors on call.</li>
  <li>The email sender is currently configured to just send to localhost, so please install something like <strong>Papercut</strong> and you should see the notification once a leave request has been created.</li>
</ul>

Running the solution
====================
<ul>
  <li>
    The nuget packages folder has not been uploaded to Git, so please ensure you have the option "Automatically check for missing packages during build in Visual Studio" checked
    <code>Tools -> NuGet Package Manager -> Package Manager Settings</code>
  </li>
  <li>Please ensure that the <strong>CompanyABC.WebClient</strong> project is "Set as StartUp Project"</li>
  <li>Ensure that within the Properties of the <strong>CompanyABC.WebClient</strong> project, that under the <strong>Web</strong> tab, that <strong>Start Action</strong> is set to <strong>Specific Page</strong> (leave blank)</li>
</ul>

<small class="pull-right">Developed by Craig McLellen &copy;</small>
<small class="pull-right">November 2014</small>

