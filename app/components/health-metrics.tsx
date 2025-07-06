"use client"

import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Progress } from "@/components/ui/progress"
import { Badge } from "@/components/ui/badge"
import { Activity, Heart, Droplets, Moon, Flame, Target } from "lucide-react"

export function HealthMetrics() {
  const metrics = [
    {
      title: "Steps Today",
      value: "8,432",
      goal: "10,000",
      progress: 84,
      icon: Activity,
      color: "text-blue-500",
      bgColor: "bg-blue-50",
    },
    {
      title: "Heart Rate",
      value: "72 bpm",
      status: "Normal",
      icon: Heart,
      color: "text-red-500",
      bgColor: "bg-red-50",
    },
    {
      title: "Water Intake",
      value: "6 glasses",
      goal: "8 glasses",
      progress: 75,
      icon: Droplets,
      color: "text-cyan-500",
      bgColor: "bg-cyan-50",
    },
    {
      title: "Sleep Last Night",
      value: "7h 23m",
      status: "Good",
      icon: Moon,
      color: "text-purple-500",
      bgColor: "bg-purple-50",
    },
    {
      title: "Calories Burned",
      value: "2,156",
      goal: "2,200",
      progress: 98,
      icon: Flame,
      color: "text-orange-500",
      bgColor: "bg-orange-50",
    },
    {
      title: "Weekly Goal",
      value: "5/7 days",
      progress: 71,
      icon: Target,
      color: "text-green-500",
      bgColor: "bg-green-50",
    },
  ]

  return (
    <Card>
      <CardHeader>
        <CardTitle className="flex items-center space-x-2">
          <Activity className="h-5 w-5 text-blue-500" />
          <span>Today's Health Metrics</span>
        </CardTitle>
      </CardHeader>
      <CardContent>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          {metrics.map((metric, index) => {
            const IconComponent = metric.icon
            return (
              <div key={index} className={`p-4 rounded-lg ${metric.bgColor}`}>
                <div className="flex items-center justify-between mb-2">
                  <div className="flex items-center space-x-2">
                    <IconComponent className={`h-5 w-5 ${metric.color}`} />
                    <span className="font-medium text-gray-900">{metric.title}</span>
                  </div>
                  {metric.status && (
                    <Badge variant="secondary" className="text-xs">
                      {metric.status}
                    </Badge>
                  )}
                </div>
                <div className="space-y-2">
                  <div className="flex items-baseline space-x-2">
                    <span className="text-2xl font-bold text-gray-900">{metric.value}</span>
                    {metric.goal && <span className="text-sm text-gray-600">/ {metric.goal}</span>}
                  </div>
                  {metric.progress && (
                    <div className="space-y-1">
                      <Progress value={metric.progress} className="h-2" />
                      <span className="text-xs text-gray-600">{metric.progress}% of goal</span>
                    </div>
                  )}
                </div>
              </div>
            )
          })}
        </div>
      </CardContent>
    </Card>
  )
}
