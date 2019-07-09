import {adminConstants} from "../_constants";

let token = JSON.parse(localStorage.getItem('token'));
const initialState = token ? {loggedIn: true, token} : {};

export function authentication(state = initialState, action) {
  switch (action.type) {
    case adminConstants.LOGIN_REQUEST:
      return {
        loggingIn: true,
        user: action.user
      };
    case adminConstants.LOGIN_SUCCESS:
      return {
        loggedIn: true,
        token: action.token
      };
    case adminConstants.LOGIN_FAILURE:
    case adminConstants.LOGOUT:
      return {};
    default:
      return state;
  }
}
