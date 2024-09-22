import { describe, expect } from 'https://jslib.k6.io/k6chaijs/4.3.4.3/index.js';
import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    vus: 1,
    iterations: 1,
};

const BASE_URL = 'http://localhost:5298';
const session = {};
const params = {
    headers: { 'Content-Type': 'application/json' }
  };

export default function() {
    describe('01. Create a keycap', (t) => {
        const payload = {
            id: 0,
            name: 'Create keycap',
            sourceUrl: 'https://example.com',
            images: []
        };

        const resp = http.post(BASE_URL + '/keycaps', JSON.stringify(payload), params);

        expect(resp.status, 'Keycap creation status').to.equal(200);
        expect(resp, 'Keycap creation valid json response').to.have.validJsonBody();

        session.newId = resp.json('id');
    });

    describe('02. Get the keycap', (t) => {
        const resp = http.get(`${BASE_URL}/keycaps/${session.newId}`);
        expect(resp.status, 'Keycap retrieval status').to.equal(200);
        expect(resp, 'Keycap retrieval valid json response').to.have.validJsonBody();
    });

    describe('03. Update the keycap', (t) => {
        const payload = {
            id: session.newId,
            name: 'Update keycap',
            sourceUrl: 'https://example.com',
            images: []
        };
        const resp = http.put(`${BASE_URL}/keycaps`, JSON.stringify(payload), params);
        expect(resp.status, 'Keycap update status').to.equal(200);
        expect(resp, 'Keycap update valid json response').to.have.validJsonBody();
    });

    describe('04. Valid keycap updated', (t) => {
        const resp = http.get(`${BASE_URL}/keycaps/${session.newId}`);

        expect(resp.status, 'Keycap retrieval status').to.equal(200);
        expect(resp, 'Keycap retrieval valid json response').to.have.validJsonBody();
        expect(resp.json('name'), 'Keycap name').to.equal('Update keycap');

    });

    describe('05. Delete the keycap', (t) => {
        const resp = http.del(`${BASE_URL}/keycaps/${session.newId}`);
        expect(resp.status, 'Keycap deletion status').to.equal(200);
    });

    sleep(1);
}
