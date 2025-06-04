# Code Assistants Testing Tasks: Week 1

June 3, 2025

## Overview

This document contains the setups involved in pulling down the synthetic repository, running your code assistants against it, and pushing it back up with edits. It also contains a list of proposed tasks with some tips and tricks attached, but developers are welcome to get creative!

We will use the code in your pull requests to drive a broader conversation about how the AI agents performed and compare the different implementations developers generated with their tools. This is not a code review; in fact, we encourage you to commit and call out any specifically poor, non-functional, or hallucinated code! This will help us drive a broader conversation about how to use, prompt, review, and commit code from agents responsibly.

## Proposed Task List

Please refer to the task number when taking notes on performance; this will help us parse feedback and make a sound recommendation at the end of the project.

1. Create documentation and adjust documentation for classes, functions, and API calls.
2. To improve the model's output here you can try passing it an example showing it the format you want to use. You can also give examples of what kinds of information you want included within the documentation.
3. Try using the /doc slash command and compare it with the output of your question prompted in the chat. See the [GitHub Copilot Cheat Sheet](https://docs.github.com/en/copilot/using-github-copilot/copilot-chat/github-copilot-chat-cheat-sheet) for more information. Here's an example of how to use it: [Video](https://www.youtube.com/shorts/vZSf9F-S_aA)
4. Add a Unit Testing framework to the project and generate unit tests with mock services.
5. Start by asking the model to strategize, for example, "how would you implement unit testing in this project with mocked services?" Ask the assistant to critique its own work. If you have any preferred libraries, ask it to incorporate those into its approach.
6. If you haven't integrated a unit-testing framework into a C# project before, here's a quick guide on how you can set one up with the help of Copilot. [Microsoft Guide](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-copilot)
7. Ask the agent to adjust styling, formatting, or buttons on the frontend.
8. Review the output and ask for further changes or adjustment. Try asking the agent to implement very broad, vague changes and see how it does. Based on what it produces initially, try being more specific and see if the result is closer to what you expected.
9. Compare this with a very targeted, detailed question with a code example.
10. Create a new API route, connect it to the frontend, and update documentation and tests.
11. Try asking the agent to implement very broad, vague changes and see how it does. Based on what it produces initially, try being more specific and see if the result is closer to what you expected.
12. This is also a good opportunity to try out different models with Copilot to see how they perform with a relatively vague task.
13. To get better performance out of the model, provide it with a list of API routes with requirements, and a description of any additional buttons or features on the frontend.
14. Prompt the agent for suggestions to improve the project and implement what you find interesting.

## Extra Credit Tasks

Optional, more advanced tasks you can try running which leverage custom configuration and tooling in Q and Copilot:

1. Ask the model to plan out a large overhaul of the application, for example converting the frontend to React or identifying and fixing any ADA compliance issues.
2. Try pre-prompting the model to follow specific development guidelines, patterns. Serve the model with examples before prompting.
3. Try some of the other commands in the tricks and tips documentation for copilot!
4. Ask GitHub Copilot to identify any security or performance issues at scale for your repository.
5. Run a code review with Amazon Q.

## Additional Resources

See below for a list of helpful articles and documentation to support your learning! Please note that the feature list for Copilot and especially Amazon Q can differ between Visual Studio Professional and VS Code. If you conduct independent research, be sure to double check that the author is working with Visual Studio Professional before trying it in your local.

### Copilot

- [GitHub Copilot documentation](https://docs.github.com/en/copilot) along with best practices. Visual studio specific documentation can be found [here](https://docs.github.com/en/copilot/configuring-github-copilot/configuring-github-copilot-in-visual-studio)
- A [deep dive into generating unit tests with Copilot](https://github.blog/2023-02-27-how-to-write-unit-tests-with-github-copilot/). See examples at the bottom of the article if you don't need the basics
- [How to add repository custom instructions to GitHub Copilot](https://docs.github.com/en/copilot/configuring-github-copilot/configuring-github-copilot-settings#adding-custom-instructions)

### Amazon Q

- [Amazon Q Documentation By IDE](https://docs.aws.amazon.com/amazonq/latest/developer-guide/ide-vs.html). Scroll down to Visual Studio to see Amazon Q features supported in the professional edition
- [How to use inline suggestions with Amazon Q For Visual Studio](https://docs.aws.amazon.com/amazonq/latest/developer-guide/use-inline-suggestions.html)
- [How to run a Code Review with Amazon Q](https://docs.aws.amazon.com/amazonq/latest/developer-guide/use-code-review.html)
