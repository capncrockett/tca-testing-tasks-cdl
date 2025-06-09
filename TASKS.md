# Code Assistants Testing Tasks: Week 1

June 9, 2025

## Overview

This document contains a list of proposed testing tasks with helpful resources included at the end.

We will use the code in your pull requests to drive a broader conversation about how the AI agents performed and compare the different implementations developers generated with their tools. This is not a code review; in fact, we encourage you to commit and call out any specifically poor, non-functional, or hallucinated code! This will help us drive a broader conversation about how to use, prompt, review, and commit code from agents responsibly.

**Please refer to the task number when taking notes on your testing experience.**

## Task 1: Documentation Enhancement

- Create and adjust documentation for classes, functions, and API calls.
- To improve the model's output, try passing it an example showing the format you want to use.
- Include examples of what kinds of information you want in the documentation.
- Try using the `/doc` slash command and compare it with chat-based documentation.

## Task 2: Unit Testing with NUnit

- Add unit tests to the existing NUnit test project.
- Generate tests with mock services where appropriate.
- Start by asking the model to strategize: "How would you implement unit testing in this project with mocked services?"
- Ask the assistant to critique its own work.

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

**Extra Credit Task 1: Frontend Testing Setup**

   - Set up a testing framework for the Vue.js frontend (e.g., Vitest or Jest)
   - Add example tests for Vue components

**Extra Credit Task 2: Integration Testing**

   - Add integration tests that test multiple components working together
   - Example: Test the complete flow of a user making a booking

**Extra Credit Task 3: Code Quality**
   - Run a code quality analysis and address any issues found
   - Example: Use built-in IDE tools to identify code smells or potential bugs

## Additional Resources

### Copilot

- General
  - [GitHub Copilot Documentation](https://docs.github.com/en/copilot)
  - [Best Practices for Using GitHub Copilot](https://docs.github.com/en/copilot/using-github-copilot/best-practices-for-using-github-copilot)
  - [GitHub Copilot Command Cheat Sheet](https://docs.github.com/en/copilot/using-github-copilot/copilot-chat/github-copilot-chat-cheat-sheet)
  - [Add Repository Custom Instructions to Copilot](https://docs.github.com/en/copilot/customizing-copilot/adding-repository-custom-instructions-for-github-copilot)
- Using Copilot in Visual Studio
  - [Configuring Copilot in Visual Studio](https://docs.github.com/en/copilot/managing-copilot/configure-personal-settings/configuring-github-copilot-in-your-environment)
  - [Asking Questions in Visual Studio](https://docs.github.com/en/copilot/using-github-copilot/copilot-chat/asking-github-copilot-questions-in-your-ide)
- Using Copilot for Unit Testing
  - [Generating Unit Tests with Copilot](https://github.blog/ai-and-ml/github-copilot/how-to-generate-unit-tests-with-github-copilot-tips-and-examples/) 
  - [Generating Unit Tests in .NET with Copilot](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-copilot)



### Amazon Q

- [Using Amazon Q in the IDE](https://docs.aws.amazon.com/amazonq/latest/qdeveloper-ug/q-in-IDE.html) 
- [Using Inline Suggestions in Visual Studio](https://docs.aws.amazon.com/amazonq/latest/qdeveloper-ug/inline-suggestions.html)
- [Run a Code Review with Q in Visual Studio](https://docs.aws.amazon.com/amazonq/latest/qdeveloper-ug/code-reviews.html)