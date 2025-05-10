# snyk-code-workshop
1. Prerequisites

public GitHub account - http://github.com

git CLI - https://git-scm.com/downloads

snyk CLI - https://support.snyk.io/hc/en-us/articles/360003812538-Install-the-Snyk-CLI

Registered account on Snyk App - http://app.snyk.io


2. Configure GitHub Integration

First we need to connect Snyk to GitHub so we can import our Repository. Do so by:

Login to http://app.snyk.io Sign up if you haven't already.
Navigating to Integrations -> Source Control -> GitHub
Fill in your Account Credentials to Connect your GitHub Account.

3. Enable Snyk Code within Snyk App

Click on the "Settings" button on the top most navigation bar as shown below
alt tag

Click on "Snyk Code", then enable it and click "Save Changes" as shown below
alt tag

4. Add project to find Snyk Code Vulnerabilities

Now that Snyk is connected to your GitHub Account, import the Repo into Snyk as a Project.

1.Navigate to Projects

2.Click "Add Project" then select "GitHub"

3.Click on the Repo you forked ""

4.Click "Add Selected Repositories"



Once complete you should see a "Code Analysis" project as shown below

Note: There are only 2 code security issues , this is deliberate, and we will try "Snyk Code" on more vulnerable projects shortly


Click on "Code Analysis" to view our SAST scan results

For each Vulnerability, Snyk displays the following:

1.Each Vulnerability grouped by severity

2.Each Vulnerability links to the CWE category code

3.Each Vulnerability shows the CWE category name

4.Displays the line of code where the security issue exists

5.Description for the issue and the code file name it exists in a link to a Snyk Learn module on how to fix these type of vulnerabilities if available

6.The ability to ignore issues you wish to remove from the list


Click on the "Full Details" button as shown below:

1.Snyk products all provide a developer-friendly experience, so Snyk Code helps developers to quickly understand the problem, learn the background, and how to approach it. 

2.Snyk Code helps you understand the dangerous code flow step-by-step. 

3.For every issue, Code also provides a link to the lines in the relevant files, to view more details on the problem like the CWE, and how to approach it.


Click on "Fix Analysis" to see how you can fix the issue based on other open source project. On this page you get not just source code example fixes but also the following detailed information:
1.Details
2.Types Of Attacks
3.Affected Environments
4.How to prevent


Do you think you could fix this issue now?

5. Snyk Code CLI Test

In addition to the Snyk App UI we also have, snyk - CLI a build-time tool to find & fix known vulnerabilities in open-source dependencies, IaC configuration files and SAST scans on the source code files itself (Snyk Code).

Note: Please ensure you have the latest version of the Snyk CLI installed a version equal to or greater than the version below

$ snyk --version

Authorize the Snyk CLI with your account as follows
$ snyk auth

Now redirecting you to our auth page, go ahead and log in,
and once the auth is complete, return to this prompt and you'll
be ready to start using snyk.

If you can't wait use this url:
https://snyk.io/login?token=ff75a099-4a9f-4b3d-b75c-bf9847672e9c&utm_medium=cli&utm_source=cli&utm_campaign=cli&os=darwin&docker=false


Your account has been authenticated. Snyk is now ready to be used.

6. Snyk Code Test using VS Code

IDE integrations use Snyk Code’s fast analysis and response, allowing you to spot an issue, understand and learn more about it, and fix it, as you write the code before you check the code in. So you can find possible security flaws in your code as you write it, on a line-by-line basis.

Snyk Code supports a VS Code plugin to support issue finding and fixing, directly from the IDE:

Install the VS Code Snyk plugin using the link below
https://docs.snyk.io/features/integrations/ide-tools/visual-studio-code-extension-for-snyk-code

Using the Snyk Icon on the left hand side let's run a "Snyk Code" Test as shown below
alt tag

Thanks for attending and completing this workshop
