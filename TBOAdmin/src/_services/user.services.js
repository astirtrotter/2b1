import {authHeader} from "../_helpers";
import {API_URL} from "../_config";

export const userServices = {
  login,
  logout,
  register
};

function login(username, password) {
  const requestOptions = {
    method: 'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({username, password})
  };

  return fetch(API_URL.LOGIN, requestOptions)
    .then(handleResponse)
    .then(token => {
      // store jwt token in local storage to keep user logged in between page refreshes
      localStorage.setItem('token', JSON.stringify(token));
      return token;
    });
}

function logout() {
  // remove token from local storage to log user out
  localStorage.removeItem('token');
}

function register(user) {
  const requestOptions = {
    method: 'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify(user)
  };

  return fetch(API_URL.REGISTER, requestOptions)
    .then(handleResponse)
    .then(token => {
      // store jwt token in local storage to keep user logged in between page refreshes
      localStorage.setItem('token', JSON.stringify(token));
      return token;
    });
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
