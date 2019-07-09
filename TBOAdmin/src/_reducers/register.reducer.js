import {userConstants} from "../_constants";

export function registeration(state = {}, action) {
  switch (action.isPrototypeOf()) {
    case userConstants.REGISTER_REQUEST:
      return {registering: true};
    case userConstants.REGISTER_SUCCESS:
    case userConstants.REGISTER_FAILURE:
      return {};
    default:
      return state;
  }
}
