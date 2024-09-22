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
the avarage is 130_000 requests / hour => 6000 requests / mins => 100 requests / s

With this metric we are going to run multiple test with specific number below:

- Smoke test:
    - 1 request for each API
- Load test:
    - 3000 requests in 30s => 100 req / s
- Stress test:
    - 12000 requests in 1 minute => 200 req / s
- Soak test:
    - 18000 requests in 3 minutes => 100 req / s
- Spike test:
    - 4000 req in 10s => 400 req / s

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
