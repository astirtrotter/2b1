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
        token => {
          dispatch(success(token));
          history.push('/');
        },
        error => {
          dispatch(failure(error.toString()));
          // alert
          //dispatch(alertActions.error(error.toString()));
        }
      )
  };

  function request(user) { return { type: userConstants.LOGIN_REQUEST, user } }
  function success(token) { return { type: userConstants.LOGIN_SUCCESS, token } }
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
        token => {
          dispatch(success(token));
          history.push('/');
        },
        error => {
          dispatch(failure(error.toString()));
          // alert
          //dispatch(alertActions.error(error.toString()));
        }
      )
  };

  function request(user) {return {type: userConstants.REGISTER_REQUEST, user}}
  function success(token) {return {type: userConstants.REGISTER_SUCCESS, token}}
  function failure(error) {return {type: userConstants.REGISTER_FAILURE, error}}
}
