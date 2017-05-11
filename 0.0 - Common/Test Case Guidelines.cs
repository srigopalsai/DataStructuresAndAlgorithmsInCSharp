/*
Developer Testing Creed

•  My test class is testing one and only one class
•  My methods are testing one and only one method at a time
•  My variables and methods names are explicit
•  My test cases are easy to read by human
•  My tests are also testing expected exception with@Test(expected=MyException.class)
•  My tests don’t need access to database
•  My tests don’t need access to network resources
•  My tests respect the usual clean code standards (length of lines, cyclomatic complexity,…)
•  My tests control side effects, limit values (max, min) and null variables (even if it throws an exception)
•  My tests can be run any time on any place without needing configuration
•  My tests are concrete (ex. dates are hardwired, not computed every time, strings too…)
•  My tests use mock to simulate/stub complex class structure or methods


Test Checklist

•  Do you have a policy about how to deal with failed unit test?
•  Do you make a distinction between pure unit test and unit integration test and when to use them?
•  Do you have a policy to distribute knowledge about conduction unit testing and unit (integration) testing and automated testing in general?
•  Do you have a policy to use unit test for (formal) regression testing?
•  Do you have a policy to keep the quality of unit tests high?
•  Do you consider the unit test code on the same level as production code?
•  Did you separate unit test code from the code under test?
•  Is there a separation between tests that need configuration files and the ones that don’t need configuration files?
•  Is there a separation pure unit test and unit integration test?
•  Can all test methods run autonomous so they don’t rely on other tests or require that they are run in a particular order?
•  Is every test able to run over and over again, in any order, and produce the same results?
•  Did you use mocks or stubs to accomplish test repeatability?
•  Did you consider positive unit tests?
•  Did you consider negative unit tests?
•  Did you consider "Stress" tests?
•  Did you consider data conformance test?
•  Did you consider Ordering tests?
•  Did you consider reference tests?
•  Did you consider existence tests?
•  Did you consider cardinality tests?
•  Did you consider process logic test?
•  Do you use code coverage tools?
•  Do you write tests for bug-fixes?
•  Do you test for specific number/datetime problems like roundings , regional settings?
•  Does the unit test method only test one specific thing?
•  Did you consider the use of a Mock library or a stub while unit integration testing?
•  Are the test suites enough self-documenting?
•  Is the name of the test method intention-revealing?
•  Did you avoid test method names with appended numbers to distinguish between them?
•  Is there a consistent naming convention for the unit test code?
•  Is your unit test fast?

*/