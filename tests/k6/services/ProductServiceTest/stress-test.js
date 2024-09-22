import { sleep } from 'k6';
import SmokeTest from './smoke-test.js';

export const options = {
    scenarios: {
        constant_request_rate: {
            executor: 'constant-arrival-rate',
            rate: 200, // number of requests per second
            timeUnit: '1s', // rate per second
            duration: '1m',
            preAllocatedVUs: 10, // initial pool of VUs
            maxVUs: 200, // maximum number of VUs
        },
    },
};

export default function() {
    SmokeTest();
    sleep(1);
}
