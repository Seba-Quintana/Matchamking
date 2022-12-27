import React from 'react'
import ResultsContainer from '../Atoms/ResultsContainer'
import PlayerSearchBar from '../Molecules/PlayerSearchBar'
import PlayerSelect from '../Molecules/PlayerResults'
import { useState } from 'react'
import PlayersSelected from '../Molecules/PlayersSelected'

const MatchmakingManagement = () => {
  const [players, setPlayers] = useState([])
  const [remainingPlayers, setRemainingPlayers] = useState([])
  const [selectedPlayers, setSelectedPlayers] = useState([])

  return (
    <>
        <PlayerSearchBar></PlayerSearchBar>
        <PlayersSelected selectedPlayers={selectedPlayers} setSelectedPlayers={setSelectedPlayers}></PlayersSelected>
        <PlayerResults remainingPlayers={remainingPlayers} setRemainingPlayers={setRemainingPlayers}></PlayerResults>
    </>
    )
}

export default MatchmakingManagement