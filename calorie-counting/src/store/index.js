import { createStore } from 'vuex'
import createPersistedState from 'vuex-persistedstate'

export default createStore({
  plugins: [createPersistedState()],
  state: {
    user: -1,
    mode: ''
  },
  mutations: {
    setUser(state, id) {
      state.user = id
    },
    unsetUser(state) {
      state.user = -1
    },
    setMode(state, mode) {
      state.mode = mode
    },
    unsetMode(state) {
      state.mode = ""
    }
  },
  actions: {
  },
  modules: {
  },
  getters: {
    selectedUser(state) { return state.user },
    selectedMode(state) { return state.mode }
  }
})
