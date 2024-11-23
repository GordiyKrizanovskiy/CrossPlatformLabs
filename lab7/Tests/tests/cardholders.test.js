const axios = require('axios');

describe('Cardholders API Tests', () => {
  const baseURL = 'http://localhost:5211/api/cardholders';

  test('GET All Cardholders - Should return status 200', async () => {
    const response = await axios.get(baseURL);
    expect(response.status).toBe(200);
    expect(Array.isArray(response.data)).toBeTruthy();
  });

  test('GET Cardholder by ID - Should return status 404 for invalid ID', async () => {
    const response = await axios.get(`${baseURL}/999`).catch(err => err.response);
    expect(response.status).toBe(404);
  });

  test('POST New Cardholder - Should return status 201', async () => {
    const newCardholder = {
      accountNumber: '12345',
      countryCode: 'UA'
    };

    const response = await axios.post(baseURL, newCardholder);
    expect(response.status).toBe(201);
    expect(response.data).toHaveProperty('cardholderId');
  });
});
