"use client"

import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Badge } from "@/components/ui/badge"
import { Progress } from "@/components/ui/progress"
import { CheckCircle, Circle, Calendar, Target, TrendingUp } from "lucide-react"
import { useState } from "react"

export function WellnessPlan() {
  const [completedTasks, setCompletedTasks] = useState<number[]>([0, 2])

  const toggleTask = (index: number) => {
    setCompletedTasks((prev) => (prev.includes(index) ? prev.filter((i) => i !== index) : [...prev, index]))
  }

  const todaysTasks = [
    { id: 0, task: "Drink 8 glasses of water", category: "Hydration", priority: "High" },
    { id: 1, task: "30-minute morning walk", category: "Exercise", priority: "Medium" },
    { id: 2, task: "Meditation for 10 minutes", category: "Mental Health", priority: "High" },
    { id: 3, task: "Eat 5 servings of fruits/vegetables", category: "Nutrition", priority: "Medium" },
    { id: 4, task: "Sleep by 10:30 PM", category: "Sleep", priority: "High" },
  ]

  const weeklyGoals = [
    { goal: "Exercise 5 times this week", progress: 60, current: 3, target: 5 },
    { goal: "Maintain 8+ hours sleep", progress: 85, current: 6, target: 7 },
    { goal: "Practice mindfulness daily", progress: 71, current: 5, target: 7 },
    { goal: "Stay hydrated every day", progress: 100, current: 7, target: 7 },
  ]

  return (
    <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
      <div className="space-y-6">
        <Card>
          <CardHeader>
            <CardTitle className="flex items-center space-x-2">
              <Calendar className="h-5 w-5 text-blue-500" />
              <span>Today's Wellness Tasks</span>
            </CardTitle>
          </CardHeader>
          <CardContent className="space-y-4">
            {todaysTasks.map((item, index) => (
              <div key={index} className="flex items-center space-x-3 p-3 rounded-lg bg-gray-50">
                <button onClick={() => toggleTask(index)}>
                  {completedTasks.includes(index) ? (
                    <CheckCircle className="h-5 w-5 text-green-500" />
                  ) : (
                    <Circle className="h-5 w-5 text-gray-400" />
                  )}
                </button>
                <div className="flex-1">
                  <p
                    className={`font-medium ${completedTasks.includes(index) ? "line-through text-gray-500" : "text-gray-900"}`}
                  >
                    {item.task}
                  </p>
                  <div className="flex items-center space-x-2 mt-1">
                    <Badge variant="outline" className="text-xs">
                      {item.category}
                    </Badge>
                    <Badge variant={item.priority === "High" ? "destructive" : "secondary"} className="text-xs">
                      {item.priority}
                    </Badge>
                  </div>
                </div>
              </div>
            ))}
            <div className="pt-4 border-t">
              <div className="flex justify-between items-center mb-2">
                <span className="text-sm font-medium">Daily Progress</span>
                <span className="text-sm text-gray-600">
                  {completedTasks.length}/{todaysTasks.length} completed
                </span>
              </div>
              <Progress value={(completedTasks.length / todaysTasks.length) * 100} className="h-2" />
            </div>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle className="flex items-center space-x-2">
              <Target className="h-5 w-5 text-green-500" />
              <span>Weekly Goals</span>
            </CardTitle>
          </CardHeader>
          <CardContent className="space-y-4">
            {weeklyGoals.map((goal, index) => (
              <div key={index} className="space-y-2">
                <div className="flex justify-between items-center">
                  <span className="font-medium text-gray-900">{goal.goal}</span>
                  <span className="text-sm text-gray-600">
                    {goal.current}/{goal.target}
                  </span>
                </div>
                <Progress value={goal.progress} className="h-2" />
                <span className="text-xs text-gray-600">{goal.progress}% complete</span>
              </div>
            ))}
          </CardContent>
        </Card>
      </div>

      <div className="space-y-6">
        <Card>
          <CardHeader>
            <CardTitle className="flex items-center space-x-2">
              <TrendingUp className="h-5 w-5 text-purple-500" />
              <span>AI-Generated Plan</span>
            </CardTitle>
          </CardHeader>
          <CardContent className="space-y-4">
            <div className="p-4 bg-gradient-to-r from-purple-50 to-blue-50 rounded-lg">
              <h4 className="font-semibold text-gray-900 mb-2">Personalized Recommendations</h4>
              <p className="text-sm text-gray-700 mb-3">
                Based on your recent activity patterns and health data, here's your optimized wellness plan:
              </p>
              <ul className="space-y-2 text-sm text-gray-700">
                <li className="flex items-start space-x-2">
                  <span className="text-green-500 mt-1">•</span>
                  <span>Increase morning cardio by 5 minutes for better energy levels</span>
                </li>
                <li className="flex items-start space-x-2">
                  <span className="text-blue-500 mt-1">•</span>
                  <span>Add 15-minute evening stretching routine to improve sleep quality</span>
                </li>
                <li className="flex items-start space-x-2">
                  <span className="text-purple-500 mt-1">•</span>
                  <span>Include omega-3 rich foods 3x per week for cognitive health</span>
                </li>
                <li className="flex items-start space-x-2">
                  <span className="text-orange-500 mt-1">•</span>
                  <span>Practice deep breathing exercises during high-stress periods</span>
                </li>
              </ul>
            </div>
            <Button className="w-full">Generate New Plan</Button>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle>Upcoming Reminders</CardTitle>
          </CardHeader>
          <CardContent className="space-y-3">
            <div className="flex items-center space-x-3 p-3 bg-yellow-50 rounded-lg">
              <div className="w-2 h-2 bg-yellow-500 rounded-full"></div>
              <div>
                <p className="font-medium text-gray-900">Hydration Check</p>
                <p className="text-xs text-gray-600">In 30 minutes</p>
              </div>
            </div>
            <div className="flex items-center space-x-3 p-3 bg-blue-50 rounded-lg">
              <div className="w-2 h-2 bg-blue-500 rounded-full"></div>
              <div>
                <p className="font-medium text-gray-900">Evening Walk</p>
                <p className="text-xs text-gray-600">At 6:00 PM</p>
              </div>
            </div>
            <div className="flex items-center space-x-3 p-3 bg-purple-50 rounded-lg">
              <div className="w-2 h-2 bg-purple-500 rounded-full"></div>
              <div>
                <p className="font-medium text-gray-900">Wind Down Time</p>
                <p className="text-xs text-gray-600">At 9:30 PM</p>
              </div>
            </div>
          </CardContent>
        </Card>
      </div>
    </div>
  )
}
