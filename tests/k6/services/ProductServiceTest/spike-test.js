import { sleep } from 'k6';
import SmokeTest from './smoke-test.js';

export const options = {
    vus: 5000,
    target: 10000,
    duration: '10s',
};

export default function() {
    SmokeTest();
    sleep(1);
}
