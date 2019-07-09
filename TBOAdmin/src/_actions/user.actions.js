import { history } from "../_helpers";
import {userConstants} from "../_constants";
import {userServices} from "../_services";

export const userActions = {
  login,
  logout,
  register
};

function login(username, password) {
  return dispatch => {
    dispatch(request({username}));
    userServices.login(username, password)
      .then(
        user => {
          dispatch(success(user));
          history.push('/');
        },
        error => {
          dispatch(failure(error.toString()));
        }
      )
  };

  function request(user) { return { type: userConstants.LOGIN_REQUEST, user } }
  function success(user) { return { type: userConstants.LOGIN_SUCCESS, user } }
  function failure(error) { return { type: userConstants.LOGIN_FAILURE, error } }
}

function logout() {
  userServices.logout();
  return {type: userConstants.LOGOUT};
}

function register(user) {
  return dispatch => {
    dispatch(request(user));

    userServices.register(user)
      .then(
        user => {
          dispatch(success());
          history.push('/login');
        },
        error => {
        }
      )
  };

  function request(user) {return {type: userConstants.REGISTER_REQUEST, user}}
  function success(user) {return {type: userConstants.REGISTER_SUCCESS, user}}
  function failure(error) {return {type: userConstants.REGISTER_FAILURE, error}}
}
