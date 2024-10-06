import { uuidv4 } from 'https://jslib.k6.io/k6-utils/1.4.0/index.js';
import { describe, expect } from 'https://jslib.k6.io/k6chaijs/4.3.4.3/index.js';
import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    vus: 1,
    iterations: 1,
};

const BASE_URL = 'http://localhost:5216';
const session = {};
let params = {
    headers: {
        'Content-Type': 'application/json',
        'Authorization': ''
    }
};

const adminSession = {};

export default function() {

    describe('01. Register', (t) => {
        const username = uuidv4().substring(0, 10);
        const email = `${username}@testing.com`;
        const password = uuidv4();

        const payload = {
            "username": username,
            "password": password,
            "email": email
        };

        const resp = http.post(BASE_URL + '/identity/register', JSON.stringify(payload), params);

        expect(resp.status, 'Register status').to.equal(200);
        session.userId = resp.json('id');
        session.username = username;
        session.password = password;
        session.email = email;
    });

    describe('02. Login', (t) => {
        const payload = {
            "username": session.username,
            "password": session.password,
        };

        const resp = http.post(BASE_URL + '/identity/login', JSON.stringify(payload), params);

        expect(resp.status, 'Login should success').to.equal(200);
        session.token = resp.body;
    });

    describe('03. Get user info without token', (t) => {
        const resp = http.get(BASE_URL + '/identity/info');
        expect(resp.status, 'Get info should return unauthorized').to.equal(401);
    });

    describe('04. Get user info with bearer token', (t) => {
        // Arrange
        params.headers.Authorization = `Bearer ${session.token}`;

        // Action
        const resp = http.get(BASE_URL + '/identity/info', params);
        const jsonString = resp.body;
        const userInfo = JSON.parse(jsonString);

        // Assert
        expect(resp.status, 'Get info should return success').to.equal(200);
        expect(userInfo.id, 'Username should match').to.equal(session.userId);
        expect(userInfo.username, 'Username should match').to.equal(session.username);
        expect(userInfo.email, 'Email should match').to.equal(session.email);
    });

    describe('05. User should not get data of all users', (t) => {
        // Arrange
        params.headers.Authorization = `Bearer ${session.token}`;

        // Action
        const resp = http.get(BASE_URL + '/users', params);

        // Assert
        expect(resp.status, 'Should return unauthorized').to.equal(403);
    });

    describe('06. Admin should get all users data', (t) => {
        const username = "admin";
        const password = "testing@123";
        const payload = {
            "username": username,
            "password": password
        }
        let resp = http.post(BASE_URL + '/identity/login', JSON.stringify(payload), params);
        adminSession.token = resp.body;

        // Arrange
        params.headers.Authorization = `Bearer ${adminSession.token}`;

        // Action
        resp = http.get(BASE_URL + '/users', params);

        // Assert
        expect(resp.status, 'Should return as success').to.equal(200);
    });

    sleep(1);
}
