# Code Assistants Testing Tasks: Week 1

June 3, 2025

## Overview

This document contains the setups involved in pulling down the synthetic repository, running your code assistants against it, and pushing it back up with edits. It also contains a list of proposed tasks with some tips and tricks attached, but developers are welcome to get creative!

We will use the code in your pull requests to drive a broader conversation about how the AI agents performed and compare the different implementations developers generated with their tools. This is not a code review; in fact, we encourage you to commit and call out any specifically poor, non-functional, or hallucinated code! This will help us drive a broader conversation about how to use, prompt, review, and commit code from agents responsibly.

## Task 1: Documentation Enhancement

- Create and adjust documentation for classes, functions, and API calls.
- To improve the model's output, try passing it an example showing the format you want to use.
- Include examples of what kinds of information you want in the documentation.
- Try using the `/doc` slash command and compare it with chat-based documentation.
  - See the [GitHub Copilot Cheat Sheet](https://docs.github.com/en/copilot/using-github-copilot/copilot-chat/github-copilot-chat-cheat-sheet)
  - Example video: [Using /doc command](https://www.youtube.com/shorts/vZSf9F-S_aA)

## Task 2: Unit Testing with NUnit

- Add unit tests to the existing NUnit test project.
- Generate tests with mock services where appropriate.
- Start by asking the model to strategize: "How would you implement unit testing in this project with mocked services?"
- Ask the assistant to critique its own work.
- For beginners: [Setting up NUnit with Copilot](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-copilot)

## Task 3: Frontend Styling and UI Improvements

- Adjust styling, formatting, or buttons on the frontend.
- Try both approaches:
  1. Start with vague requests and refine based on output
  2. Provide specific, detailed requirements with code examples
- Compare the results of both approaches

## Task 4: API Development

- Create a new API route and connect it to the frontend.
- Update documentation and tests accordingly.
- Try different prompting styles:
  - Broad, vague requests first
  - Then more specific requirements
  - Compare the results

## Task 5: Model Comparison

- Try the same tasks with different AI models in Copilot.
- Note differences in output quality and approach.
- Provide the model with API routes and frontend requirements to test performance.

## Task 6: Project Improvement

- Ask the agent for suggestions to improve the project.
- Implement the most interesting or valuable suggestions.
- Document the before/after and reasoning.

## Extra Credit Tasks

1. **Frontend Testing Setup**

   - Set up a testing framework for the Vue.js frontend (e.g., Vitest or Jest)
   - Add example tests for Vue components

2. **Integration Testing**

   - Add integration tests that test multiple components working together
   - Example: Test the complete flow of a user making a booking

3. **Code Quality**
   - Run a code quality analysis and address any issues found
   - Example: Use built-in IDE tools to identify code smells or potential bugs

## Additional Resources

### Copilot

- [GitHub Copilot documentation](https://docs.github.com/en/copilot)
- [Visual Studio specific documentation](https://docs.github.com/en/copilot/configuring-github-copilot/configuring-github-copilot-in-visual-studio)
- [Generating unit tests with Copilot](https://github.blog/2023-02-27-how-to-write-unit-tests-with-github-copilot/)
- [GitHub Copilot Cheat Sheet](https://docs.github.com/en/copilot/using-github-copilot/copilot-chat/github-copilot-chat-cheat-sheet)
- [Using /doc command video](https://www.youtube.com/shorts/vZSf9F-S_aA)

### Amazon Q

- [Amazon Q for Visual Studio](https://docs.aws.amazon.com/amazonq/latest/developer-guide/ide-vs.html)
- [Code Review with Amazon Q](https://docs.aws.amazon.com/amazonq/latest/developer-guide/use-code-review.html)

### Testing Resources

- [Microsoft Guide to Unit Testing](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-copilot)
- [Deep dive into generating unit tests with Copilot](https://github.blog/2023-02-27-how-to-write-unit-tests-with-github-copilot/)
