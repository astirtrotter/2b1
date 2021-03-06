import { history } from "../_helpers";
import {adminConstants} from "../_constants";
import {authServices} from "../_services";

export const authActions = {
  login,
  logout,
  register,
  getInfo
};

function login(username, password) {
  return dispatch => {
    dispatch(request({username}));
    authServices.login(username, password)
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

  function request(admin) { return { type: adminConstants.LOGIN_REQUEST, admin } }
  function success(token) { return { type: adminConstants.LOGIN_SUCCESS, token } }
  function failure(error) { return { type: adminConstants.LOGIN_FAILURE, error } }
}

function logout() {
  authServices.logout();
  return {type: adminConstants.LOGOUT};
}

function register(admin) {
  return dispatch => {
    dispatch(request(admin));

    authServices.register(admin)
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

  function request(admin) {return {type: adminConstants.REGISTER_REQUEST, admin}}
  function success(token) {return {type: adminConstants.REGISTER_SUCCESS, token}}
  function failure(error) {return {type: adminConstants.REGISTER_FAILURE, error}}
}

function getInfo() {
  return dispatch => {
    dispatch(request());

    authServices.getInfo()
      .then(
        admin => {
          dispatch(success(admin));
        },
        error => {
          dispatch(failure(error.toString()));
          // alert
          //dispatch(alertActions.error(error.toString()));
        }
      )
  };

  function request() {return {type: adminConstants.GET_INFO_REQUEST}}
  function success(admin) {return {type: adminConstants.GET_INFO_SUCCESS, admin}}
  function failure(error) {return {type: adminConstants.GET_INFO_REQUEST, error}}
}
