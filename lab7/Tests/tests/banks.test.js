const axios = require('axios');

describe('Banks API Tests', () => {
  const baseURL = 'http://localhost:5211/api/banks';

  test('GET All Banks - Should return status 200', async () => {
    const response = await axios.get(baseURL);
    expect(response.status).toBe(200);
    expect(Array.isArray(response.data)).toBeTruthy();
  });

  test('POST New Bank - Should return status 201', async () => {
    const newBank = {
      bankName: 'Test Bank'
    };

    const response = await axios.post(baseURL, newBank);
    expect(response.status).toBe(201);
    expect(response.data).toHaveProperty('bankId');
  });
});
