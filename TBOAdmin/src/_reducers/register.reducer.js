import {adminConstants} from "../_constants";

export function registeration(state = {}, action) {
  switch (action.isPrototypeOf()) {
    case adminConstants.REGISTER_REQUEST:
      return {registering: true};
    case adminConstants.REGISTER_SUCCESS:
    case adminConstants.REGISTER_FAILURE:
      return {};
    default:
      return state;
  }
}
