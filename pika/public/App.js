import { declare, Union } from "./fable-library.2.3.19/Types";
import { union } from "./fable-library.2.3.19/Reflection";
import * as react from "/web_modules/react.js";
import { Helpers$$$equalsButFunctions as Helpers$0024$0024$0024equalsButFunctions } from "./Fable.React.5.2.7/Fable.React.Helpers";
import { FunctionComponent$$$Of$$Z603636D8 as FunctionComponent$0024$0024$0024Of$0024$0024Z603636D8 } from "./Fable.React.5.2.7/Fable.React.FunctionComponent";
import * as react$002Ddom from "/web_modules/react-dom.js";
export const Msg = declare(function App_Msg(tag, name, ...fields) {
  Union.call(this, tag, name, ...fields);
}, Union);
export function Msg$reflection() {
  return union("App.Msg", [], Msg, () => ["Increase", "Decrease"]);
}
export const App = FunctionComponent$0024$0024$0024Of$0024$0024Z603636D8(function () {
  const init = 0;

  const update = function update(state, msg) {
    if (msg.tag === 1) {
      return state - 1 | 0;
    } else {
      return state + 1 | 0;
    }
  };

  const state$$1 = react.useReducer(update, init);
  return react.createElement("div", {}, ...[react.createElement("h1", {}, ...["Pika pika"]), react.createElement("div", {
    className: "card"
  }, ...[react.createElement("div", {
    className: "card-body"
  }, ...[react.createElement("h2", {
    className: "card-title"
  }, ...["Current state:"]), react.createElement("h2", {
    className: "text-center"
  }, ...[react.createElement("strong", {}, ...[state$$1[0]])]), react.createElement("button", {
    className: "btn btn-primary mr-2",
    onClick: function (_arg1) {
      state$$1[1](new Msg(0, "Increase"));
    }
  }, ...["Increase"]), react.createElement("button", {
    className: "btn btn-secondary",
    onClick: function (_arg2) {
      state$$1[1](new Msg(1, "Decrease"));
    }
  }, ...["Decrease"])])])]);
}, "App", function (x, y) {
  return Helpers$0024$0024$0024equalsButFunctions(null, null);
});
react$002Ddom.render(App(), document.getElementById("app"));