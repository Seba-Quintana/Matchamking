import React from 'react'
import ResultsContainer from '../Atoms/ResultsContainer'
import PlayerSearchBar from '../Molecules/PlayerSearchBar'
import PlayerSelect from '../Molecules/PlayerSelect'

const MatchmakingManagement = () => {
  return (
    <>
        <PlayerSearchBar></PlayerSearchBar>
        <PlayerSelect></PlayerSelect>
    </>
    )
}

export default MatchmakingManagement