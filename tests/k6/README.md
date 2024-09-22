# K6 - API Testing

## Introduction

In this project, I will perform some smoke, stress, spike, soak testing in every API in service to see how it's executed.

## Testing guides

### Types

There are several types of API testing simulate many scenarios which the system may deal with. For comprehensive preparation, teams must test the system against different test types. 
![](./assets/chart-load-test-types-overview.png)

The main types are as follow:

- Smoke test: 
    - **Small** number of requests.
    - Check if the application perform as expected functions.
- Load test:
    - **Avarage** number of requests.
    - To see if the system maintain the performance with normal usage.
    - Let say if we implement a new feature, and the metric increase much more
    than our expectation, we would think about benchmark.
- Stress test:
    - **Higher than Avarage** number of requests.
    - To check if the system recieve more requests than normal in a mid time.
- Soak test:
    - The number of requests are the same as load test however run in **longer**.
    - To check system reliability and perform with normal usage in the long time.
- Spike test:
    - **Massive** number of requests in a short time.
    - To check if your system perform well in event or session.
- Break-point test:
    - Increase until your system fail.

### Examples

Let say your application launched for a month, and as the metric showing
the avarage is 2500 requests / hour => 100 requests / mins => 2 requests / s

With this metric we are going to run multiple test with specific number below:

- Smoke test:
    - 1 request for each API
- Load test:
    - 100 requests in 1 minute.
- Stress test:
    - 200 requests in 1 minute.
- Soak test:
    - 500 requests in 5 minutes.
- Spike test:
    - 200 requests in 30s (higher 4 times than normal).

## Run on local

1. Install k6 in local

I'm using arch linux, so installing k6 via AUR:

```sh
yay -Sy k6
```

For another system, please follow this link to find your own: https://grafana.com/docs/k6/latest/set-up/install-k6/

2. Run sample test

Run below command to start the first sample test case:

```sh
k6 run script.js
```
