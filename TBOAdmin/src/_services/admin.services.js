import {authHeader} from "../_helpers";
import {apiUrl} from "../_config";

export const adminServices = {
  login,
  logout,
  register,
  getInfo
};

function login(adminId, password) {
  const requestOptions = {
    method: 'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({adminId, password})
  };

  return fetch(apiUrl.adminLogin, requestOptions)
    .then(handleResponse)
    .then(token => {
      // store jwt token in local storage to keep admin logged in between page refreshes
      localStorage.setItem('token', JSON.stringify(token));
      return token;
    });
}

function logout() {
  // remove token from local storage to log out
  localStorage.removeItem('token');
}

function register(admin) {
  const requestOptions = {
    method: 'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify(admin)
  };

  return fetch(apiUrl.adminRegister, requestOptions)
    .then(handleResponse)
    .then(token => {
      // store jwt token in local storage to keep admin logged in between page refreshes
      localStorage.setItem('token', JSON.stringify(token));
      return token;
    });
}

function getInfo() {
  const requestOptions = {
    method: 'GET',
    headers: {...authHeader(), 'Content-Type': 'application/json'},
  };

  return fetch(apiUrl.adminGetInfo, requestOptions).then(handleResponse);
}

function handleResponse(response) {
  return response.text().then(text => {
    const data = text && JSON.parse(text);
    if (!response.ok) {
      if (response.status === 401) {
        // auto logout if 401 response returned from api
        logout();
        location.reload();
      }

      const error = (data && data.message) || response.statusText;
      return Promise.reject(error);
    }

    return data;
  });
}
